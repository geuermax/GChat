import Vue from 'vue'
import App from './App.vue'
import { createProvider } from './vue-apollo'
import Keycloak from 'keycloak-js';

Vue.config.productionTip = false

let initOptions = {
  url: 'http://localhost:80/auth',
  realm: 'master',
  clientId: 'api-dev'
}

var keycloak = new Keycloak(initOptions);
keycloak.init()
  .then(function (authenticated) {
    if (!authenticated) {
      keycloak.login();
    } else {
      window.keycloak = keycloak;
      const apolloProvider = createProvider();
      new Vue({
        apolloProvider: apolloProvider,
        render: h => h(App)
      }).$mount('#app')
    }
  });
