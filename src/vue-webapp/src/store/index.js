import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    isMobile: false
  },
  mutations: {
    setIsMobile(state, val) {
      // console.log(val);
      state.isMobile = val;
    }
  },
  actions: {
  },
  modules: {
  }
});
