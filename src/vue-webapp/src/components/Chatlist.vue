<template>
  <div class="mx-chat-list">
    <v-btn class="mx-create-chat-btn" block><v-icon class="mx-btn-icon">{{ icons.mdiCommentEditOutline }}</v-icon> Create chat</v-btn>
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

@media (max-width: 960px) {
  .mx-chat-list {
    display: none;
  }
}

@media (min-width: 960px) {
  .mx-chat-list {
    width: 30%;
  }
}

@media (min-width: 1264px) {
  .mx-chat-list {
    width: 20%;
  }
}


@media (min-width: 1904px) {
  .mx-chat-list {
    width: 15%;
  }
}




</style>
