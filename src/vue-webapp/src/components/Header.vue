<template>
  <v-app-bar dense color="#24292E">
      <v-icon class="mx-header-icon" role="img" color="#94a3b9" size="32">
        {{ mdiMessageText }}
      </v-icon>
  </v-app-bar>  
</template>

<script>


// Icon import
import { mdiMessageText } from '@mdi/js';

export default {
    name: 'Header',
    data: function() {
      return {
        mdiMessageText
      };
    }
};
</script>

<style>
.mx-header-icon {
  transform: scaleX(-1);
  color: var(--color-light-grey);
}
</style>
