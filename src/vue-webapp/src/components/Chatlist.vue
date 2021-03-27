<template>
  <div class="mx-chat-list">
    <v-btn class="mx-create-chat-btn" block small><v-icon class="mx-btn-icon" small>{{ icons.mdiCommentEditOutline }}</v-icon> Create chat</v-btn>
  </div>
</template>

<script>
import { mdiCommentEditOutline } from '@mdi/js';

export default {
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
  padding: 15px;
  height: 100%;
  background: var(--sidebar-bg);
  border-right: 2px solid var(--color-light-grey);
}

.mx-chat-list .mx-create-chat-btn {
  color: var(--color-light) !important;
  background: var(--color-blue) !important;
}

.mx-btn-icon {
  margin-right: 5px;
}

</style>
