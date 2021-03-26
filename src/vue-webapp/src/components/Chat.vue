<template>
  <div class="mx-chat" ref="mxChat">
    <Messagelist></Messagelist>
    <Message-input></Message-input>
  </div>
</template>

<script>

// Component import
import MessageInput from './message/MessageInput.vue';
import Messagelist from './message/Messagelist.vue';

export default {
	components: { Messagelist, MessageInput },
    name: 'Chat',    
};
</script>

<style>
.mx-chat {  
  position: relative;
  /* background: green; */
  height: 100%;    
  flex: 1;  
}
</style>
