<template>
  <v-app>
    <Header></Header>
    <v-main>
      <router-view></router-view>
    </v-main>
    <Firststart-dialog v-model="test"></Firststart-dialog>
  </v-app>
</template>

<script>
// Component import
import Header from '@/components/Header.vue';
import FirststartDialog from './components/firststart/FirststartDialog.vue';

// Vuex import
import { mapState, mapMutations } from 'vuex';

export default {
  name: 'App',
  components: {
    Header,
    FirststartDialog,
  },
  computed: {
    ...mapState({
      isMobile: state => state.isMobile
    })
  },
  mounted: function() {
    this.checkIsMobile();
    window.addEventListener('resize', this.checkIsMobile, {passive: true});
  },
  data: () => ({
    test: false, // show if no user exist in prod
    
  }),
  methods: {
    ...mapMutations(['setIsMobile']),
    checkIsMobile() {    
      let mobile = window.innerWidth < 960;      
      this.setIsMobile(mobile);            
    }
  }
};
</script>

<style>
:root {
  --header-bg: #24292E;
  --sidebar-bg: #2B3A4F;
  --color-light: #ffffff;
  --color-light-grey: #94A3B9;
  --color-light-grey1: #e5e5e5;
  --color-grey: #C4C4C4;
  --color-dark: #24292E;
  --color-success: #57CA85;
  --color-warning: #F8C300;
  --color-blue: #206DD8;
  --color-blue1: #7289DA;
}

html {
  overflow: auto !important;
}

::-webkit-scrollbar {
  width: 10px;
}

::-webkit-scrollbar-thumb {
  background: rgba(0,0,0,0.2);
}

::-webkit-scrollbar-thumb:hover {
  background: rgba(0,0,0,0.4);
}


body {
  scrollbar-color: rgba(0,0,0,0.4) transparent;
  scrollbar-width: 11px;
}


</style>
