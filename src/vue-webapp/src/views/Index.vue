<template>
    <div class="mx-index">
        <v-icon size="50%" color="#94A3B9" class="mx-page-icon">
            {{ mdiMessageText }}
        </v-icon>
    </div>
</template>

<script>
// Icon import
import { mdiMessageText } from '@mdi/js';


export default {
    name: 'IndexView',
    data: function() {
        return {
            mdiMessageText
        };
    }
};
</script>

<style>
.mx-page-icon {
    transform: scaleX(-1);    
}
.mx-index {
    height: calc(100vh - 48px);
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>
