<template>
  <v-dialog v-model="showDialog" persistent max-width="600px">
      <v-card>
          <v-card-title>
              Enter username
          </v-card-title>
          
          <v-card-text>
              <v-text-field solo placeholder="Enter username here" v-model="username" @keydown="inputKeydownEventHandler"></v-text-field>
          </v-card-text>

          <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn @click="submitUsername" color="#206DD8" text>Create</v-btn>
          </v-card-actions>
      </v-card>
  </v-dialog>
</template>

<script>
export default {
    name: 'FirststartDialog',
    props: ['value'],    
    mounted: function() {
        this.showDialog = this.value;
    },
    watch: {
        showDialog: function() {            
            this.$emit('input', this.showDialog);
        }
    },
    data: function() {
        return {
            showDialog: false,
            username: ''
        };
    },
    methods: {
        submitUsername() {
            console.log('Submit username');
            this.showDialog = false;
        },
        inputKeydownEventHandler(e) {            
            if (e.key === 'Enter') {
                this.submitUsername();
            }
        }
    }
};
</script>
