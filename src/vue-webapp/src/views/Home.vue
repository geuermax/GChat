<template>
  <div class="mx-home">
    <Chatlist v-if="!isMobile"></Chatlist>
    <!-- <Chat></Chat> -->
    <router-view></router-view>
  </div>
</template>

<script>
// Component import
import Chatlist from '@/components/Chatlist.vue';
// import Chat from '@/components/Chat.vue';

export default {
	components: { Chatlist, /*Chat*/ },
  name: 'Home',    
  mounted: function() {
    this.setIsMobile();
    window.addEventListener('resize', this.setIsMobile, {passive: true});
  },
  data: function() {
    return {
      isMobile: false
    };
  },
  methods: {
    setIsMobile() {      
      this.isMobile = window.innerWidth < 960;
    }
  }

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
