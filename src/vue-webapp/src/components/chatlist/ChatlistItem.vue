<template>
  <li class="mx-chatlist-item">
      <div class="mx-chatlist-item-start">
        <div>
            <Avatar :input="participants[0].username"></Avatar>
        </div>
        <div class="mx-chat-description">
            <div class="mx-chat-name">{{ participants[0].username }}</div>
            <div class="mx-chat-last-message">
                {{ getLastMessage }}
            </div>
        </div>
      </div>
      <div class="mx-chat-timestamp">12:41 Uhr</div>
  </li>
</template>

<script>
import Avatar from '../avatar/Avatar.vue';

import { mapGetters } from 'vuex';


export default {
	components: { Avatar },
    name: 'ChatlistItem',
    props: {
        chat: {
            type: Object,
            required: true
        }
    },
    computed: {
        ...mapGetters(['getSubject']),
        participants: function() {
            let me = this.getSubject;            
            let withoutMe = this.chat.participants.filter(i => i.id !== me);
            return withoutMe;            
        },
        getLastMessage: function() {
            return 'Add last message';
        }
    },
};
</script>

<style>
.mx-chatlist-item {
    position: relative;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: space-between;
    flex-grow: 1;
    color: var(--color-light);       
    border-bottom: 1px solid var(--color-light-grey);
    padding: 15px 10px 15px 10px;
    cursor: pointer;
}

.mx-chatlist-item:hover::after {
    background: rgba(255,255,255,0.15);
    height: 100%;
    width: 100%;
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    border-radius: 7px;
}

.mx-chatlist-item .mx-chatlist-item-start {
    display: flex;
    flex-direction: row;  
    flex-grow: 1;
    overflow: auto;
} 


.mx-chatlist-item .mx-chat-description {
    margin: 0 15px 0 15px;
    flex-grow: 1;
    overflow: auto;
}

.mx-chatlist-item .mx-chat-description .mx-chat-last-message {
    font-size: 0.75rem;
    color: var(--color-light-grey);
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
}

.mx-chatlist-item .mx-chat-timestamp {
    font-size: 0.75rem;
    display: inline-block;
    white-space: nowrap;    
}
</style>
