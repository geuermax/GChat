import Vue from 'vue'
import App from './App.vue'
import { createProvider } from './vue-apollo'
import Keycloak from 'keycloak-js';
import gql from 'graphql-tag';

Vue.config.productionTip = false

let initOptions = {
  url: 'http://localhost:80/auth',
  realm: 'master',
  clientId: 'api-dev'
}

var keycloak = new Keycloak(initOptions);
keycloak.init({ checkLoginIframe: false })
  .then(function (authenticated) {
    if (!authenticated) {
      keycloak.login();
    } else {
      window.keycloak = keycloak;
      const apolloProvider = createProvider();
      const app = new Vue({
        apolloProvider: apolloProvider,
        render: h => h(App)
      }).$mount('#app');


      setInterval(() => {
        console.log('interval');
        keycloak.updateToken(70)
          .then((refreshed) => {
            if (refreshed) {
              console.log("Token refreshed.");
              app.$apollo.mutate({
                mutation: gql`
                  mutation renewWsAuth($token: String!) {
                    renewWsAuth(token: $token)
                  }`,
                variables: {
                  token: keycloak.token
                },
                update: (store, { data }) => {
                  console.log(data.renewWsAuth);
                }
              });
            } else {
              console.warn('Token not refreshed, valid for ' + Math.round(keycloak.tokenParsed.exp + keycloak.timeSkew - new Date().getTime() / 1000) + ' seconds');
            }
          })
          .catch((error) => {
            console.error('Error while updateing token. ' + error);
          })
      }, 30000);


    }
  });
