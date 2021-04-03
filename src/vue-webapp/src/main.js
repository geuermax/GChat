import Vue from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import vuetify from './plugins/vuetify';

Vue.config.productionTip = false;

import Keycloak from 'keycloak-js';
import { createProvider } from './vue-apollo';


const keycloakConfig = {
  url: 'http://localhost:80/auth',
  realm: 'master',
  clientId: 'vue-dev'
};

// @ts-ignore
var keycloak = new Keycloak(keycloakConfig);

keycloak.init({
  onload: 'login-required'
})
  .then(function (authenticated) {
    console.debug('User authenticated? ' + authenticated);

    if (!authenticated) {
      keycloak.login();
    }

    store.commit('setKeycloak', keycloak);
    new Vue({
      router,
      store,

      // @ts-ignore
      vuetify,

      apolloProvider: createProvider(),

      // @ts-ignore
      render: function (h) { return h(App); }
    }).$mount('#app');
  })
  .catch(function (err) {
    console.debug('Authentication error: ' + err);
    alert('Something went worng with your authentication. Please try again.');
  });




