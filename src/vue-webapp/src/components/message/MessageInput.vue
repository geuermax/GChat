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
    mounted: function() {
        this.setWidth();
        window.onresize = () => {
            this.setWidth();
        };    
    },
    data: function() {
        return {
            width: 0,
            icons: {
                mdiSend
            }
        };
    },
    methods: {
        setWidth: function() {
            this.width = this.width = this.$refs.mxMessageInputWrapper.__vue__.$parent.$el.offsetWidth;
        },
        sendClickedHandler: function() {
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
    padding: 15px;    
}

.mx-message-input-wrapper .mx-message-input {    
    height: 50px;    
}
</style>
