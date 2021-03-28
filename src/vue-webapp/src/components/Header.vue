<template>
  <v-app-bar dense color="#24292E">
      <v-icon class="mx-header-icon" role="img" color="#94a3b9" size="32" @click="iconClickedHandler">
        {{ mdiMessageText }}
      </v-icon>
  </v-app-bar>  
</template>

<script>
// Icon import
import { mdiMessageText } from '@mdi/js';

// Vuex import
import { mapState } from 'vuex';

export default {
    name: 'Header',
    computed: {
      ...mapState({
        isMobile: state => state.isMobile
      })
    },
    data: function() {
      return {
        mdiMessageText
      };
    },
    methods: {
      iconClickedHandler() {
        if (this.isMobile) {
          if (this.$route.fullPath != '/chats') {
            this.$router.push('/chats');
          } else {
            this.$router.push('/');
          }
        }
      }
    }
};
</script>

<style>
.mx-header-icon {
  transform: scaleX(-1);
  color: var(--color-light-grey);
}
</style>
