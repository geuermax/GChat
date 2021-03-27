<template>
  <div class="mx-chat-list">
    <div class="mx-create-chat-btn-wrapper">
      <v-btn class="mx-create-chat-btn" block small><v-icon class="mx-btn-icon" small>{{ icons.mdiCommentEditOutline }}</v-icon> Create chat</v-btn>
    </div>
    <ul class="mx-chat-list-list">
      <Chatlist-item></Chatlist-item>
      <Chatlist-item></Chatlist-item>
      
    </ul>
  </div>
</template>

<script>
import { mdiCommentEditOutline } from '@mdi/js';
import ChatlistItem from './chatlist/ChatlistItem.vue';

export default {
	components: { ChatlistItem },
    name:'Chatlist',
    data: function() {
      return {
        icons: {
          mdiCommentEditOutline
        }
      };
    }
};
</script>

<style>
.mx-chat-list {  
  padding: 10px;  
  background: var(--sidebar-bg);
  border-right: 2px solid var(--color-light-grey);
  overflow-y: scroll;
  height: calc(100vh - 48px);
}

.mx-chat-list .mx-create-chat-btn {
  color: var(--color-light) !important;
  background: var(--color-blue) !important;  
}

.mx-create-chat-btn-wrapper {
  padding: 5px 5px 15px 5px;
}

.mx-btn-icon {
  margin-right: 5px;
}

.mx-chat-list-list {  
  padding: 0 !important;
  list-style-type: none;
  /* overflow: scroll;     */
}

</style>
