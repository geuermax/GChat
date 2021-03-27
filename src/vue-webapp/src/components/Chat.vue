<template>
  <div class="mx-chat" ref="mxChat">
    <Messagelist></Messagelist>
    <Message-input :width="width"></Message-input>
  </div>
</template>

<script>

// Component import
import MessageInput from './message/MessageInput.vue';
import Messagelist from './message/Messagelist.vue';

export default {
	components: { Messagelist, MessageInput },
  name: 'Chat',  
  mounted: function() {
    this.setWidth();
    window.addEventListener('resize', this.setWidth, { passive: true });
  },
  data: function() {
    return {
      width: 1
    };
  },
  methods: {
    setWidth() {      
      this.width = this.$refs.mxChat != undefined ? this.$refs.mxChat.offsetWidth : this.width;      
    }
  }
};
</script>

<style>

</style>
