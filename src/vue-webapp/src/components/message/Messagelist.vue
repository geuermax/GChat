<template>
  <ul class="mx-messagelist">
    <Message :message="testMessage"></Message>
    <Message type="revert" :message="testMessage"></Message>
  </ul>
</template>

<script>
import Message from './Message.vue';
export default {
	components: { Message },
  name:'Messagelist',
  data: function() {
    return {
      testMessage: {
        text: 'Test Nachricht',
        timestamp: 1616872467139,
        sender: {
          username: 'Max Geuer'
        }
      }
    };
  }
};
</script>

<style>
.mx-messagelist {
  list-style-type: none;
  overflow-y: scroll;
  scroll-behavior: smooth;
  padding: 15px 15px 0 15px !important;
  height: calc(100vh - 48px - 80px);
  margin: 0 0 80px 0;
  display: flex;
  flex-direction: column-reverse;
}


</style>
