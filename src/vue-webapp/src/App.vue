<template>
  <v-app>
    <Header></Header>
    <v-main>
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
// Component import
import Header from '@/components/Header.vue';

export default {
  name: 'App',

  components: {
    Header,
  },

  data: () => ({
    //
  }),
};
</script>

<style>
:root {
  --header-bg: #24292E;
  --color-light: #ffffff;
  --color-light-grey: #94A3B9;
  --color-dark: #24292E;
  --color-success: #57CA85;
  --color-warning: #F8C300;
}
</style>
