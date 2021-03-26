<template>
  <div class="mx-home">
    <Chatlist></Chatlist>
    <Chat></Chat>
  </div>
</template>

<script>
// Component import
import Chatlist from '@/components/Chatlist.vue';
import Chat from '@/components/Chat.vue';

export default {
	components: { Chatlist, Chat },
  name: 'Home',
};
</script>

<style>
.mx-home {
  height: 100%;
  display: flex;
  flex-direction: row;
  align-items: stretch;
}
</style>
