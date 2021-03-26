<template>
  <div class="mx-header">
      <v-icon class="mx-header-icon" role="img" color="#94a3b9" size="40">
        {{ mdiMessage }}
      </v-icon>
  </div>
</template>

<script>


// Icon import
import { mdiMessage } from '@mdi/js';

export default {
    name: 'Header',
    data: function() {
      return {
        mdiMessage
      };
    }
};
</script>

<style>
.mx-header {
  background: var(--header-bg);
  color: var(--color-light-grey);
  height: 75px;
  display: flex;
  align-items: center;
  padding: 0 15px;
}

.mx-header .mx-header-icon {
  transform: scaleX(-1);
  color: var(--color-light-grey);
}
</style>
