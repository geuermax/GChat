<template>
  <div class="mx-chat-list">
    <div class="mx-create-chat-btn-wrapper">
      <v-btn class="mx-create-chat-btn" block small><v-icon class="mx-btn-icon" small>{{ icons.mdiCommentEditOutline }}</v-icon> Create chat</v-btn>
    </div>
    <ul class="mx-chat-list-list">
      <Chatlist-item v-for="(item, index) in chats" :key="index" :chat="item"></Chatlist-item>            
    </ul>
  </div>
</template>

<script>
import { mdiCommentEditOutline } from '@mdi/js';
import ChatlistItem from './chatlist/ChatlistItem.vue';
import { chats } from '@/graphql'; 
import { mapState, mapMutations } from 'vuex';



export default {
	components: { ChatlistItem },
    name:'Chatlist',
    computed: {
      ...mapState({
        chats: state => state.chats.chats
      })
    },
    data: function() {
      return {
        icons: {
          mdiCommentEditOutline
        },
      };
    },
    methods: {
      ...mapMutations(['setChats'])
    },
    apollo: {
      queryChats: {
        query: chats,
        update: function(data) {
          console.log(data.chats);     
          this.setChats(data.chats);  
        }
      }
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
