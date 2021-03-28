<template>
  <div class="mx-home">
    <Chatlist v-if="!isMobile"></Chatlist>    
    <router-view></router-view>
  </div>
</template>

<script>
// Component import
import Chatlist from '@/components/Chatlist.vue';

// Vuex import
import { mapState } from 'vuex';

export default {
	components: { Chatlist },
  name: 'Home',
  computed: {
    ...mapState({
      isMobile: state => state.isMobile
    })
  },
};
</script>

<style>
.mx-home {
  height: 100%;
  display: grid;  
}

@media (min-width: 960px) {
  .mx-home {
    grid-template-columns: minmax(0, 3fr) 7fr;
  }
}

@media (min-width: 1650px) {
  .mx-home {
    grid-template-columns: minmax(0, 2fr) 8fr;
  }
}


@media (min-width: 2600px) {
  .mx-home {
    grid-template-columns: minmax(0, 1fr) 9fr;
  }
} 



</style>
