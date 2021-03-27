<template>
  <div class="mx-message-input-wrapper" ref="mxMessageInputWrapper" :style="`width: ${width}px`">
      <v-text-field class="mx-message-input" solo placeholder="Enter Message" :append-icon="icons.mdiSend" @click:append="sendClickedHandler"></v-text-field>
  </div>
</template>

<script>

// Icon import
import { mdiSend } from '@mdi/js';

export default {
    name: 'MessageInput',
    props: {
        width: {
            type: Number,
            required: true
        }
    },
    data: function() {
        return {           
            icons: {
                mdiSend
            }
        };
    },
    methods: {
        sendClickedHandler() {
            console.log('Send clicked');
        }
    }
};
</script>

<style>
.mx-message-input-wrapper {
    height: 80px;    
    position: fixed;
    bottom: 0;
    right: 0;
    padding: 15px;    
    width: 100%;
}

.mx-message-input-wrapper .mx-message-input {    
    height: 50px;
}
</style>
