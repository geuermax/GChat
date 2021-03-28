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

export default {
  name: 'App',

  components: {
    Header,
    FirststartDialog,
  },

  data: () => ({
    test: true
  }),
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
  overflow: hidden !important;
}
</style>
