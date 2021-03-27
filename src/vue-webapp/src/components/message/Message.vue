<template>
  <li class="mx-message" :class="type">
    <Avatar :input="message.sender.username"></Avatar>
    <div class="mx-message-text">
      {{ message.text }}
      <div class="mx-message-timestamp">
        {{ getTime }} Uhr
      </div>
    </div>    
  </li>
</template>

<script>
import Avatar from '../avatar/Avatar.vue';
export default {
	components: { Avatar },
    name: 'Message',
    props: {
      type: {
        type: String,
        default: 'normal'
      },
      message: {
        type: Object,
        required: true
      }      
    },
    watch: {
      type: (oldValue, newValue) => {
        if (newValue != 'normal' || newValue != 'revert') {
          throw new Error(`Property type has to be normal or revert. Oldvalue: ${oldValue}; Newvalue: ${newValue}`);
        }
      }
    },
    computed: {
      getTime() {
        let timestamp = new Date(this.message.timestamp);        
        return `${timestamp.getHours()}:${timestamp.getMinutes()}`;
      }
    }
};
</script>

<style>
.mx-message-text {
  width: 65%;
  min-height: 55px;  
  border-radius: 5px;  
  padding: 10px 5px;
}

.mx-message-timestamp {
  font-size: 0.75rem;
  text-align: end;  
  color: var(--color-light-grey1);
}

.mx-message {
  width: 100%;
  display: flex;  
  padding: 7px 0 8px 0;
}

.mx-message.normal {
  flex-direction: row;
}

.mx-message.revert {
  flex-direction: row-reverse;
}

.mx-message.normal .mx-message-text {
  margin-left: 15px;
  background: var(--color-blue);
  color: var(--color-light);
}

.mx-message.revert .mx-message-text {
  margin-right: 15px;
  background: var(--color-blue1);
  color: var(--color-light);
}

.mx-message.revert .mx-message-text .mx-message-timestamp {
  text-align: start;
}



@media (min-width: 960px) {
  .mx-message-text {
    width: 75%;
  }
}

@media (min-width: 1264px) {
  .mx-message-text {
    width: 55%;
  }
}

@media (min-width: 2600px) {
  .mx-message-text {
    width: 40%;
  }
} 

</style>
