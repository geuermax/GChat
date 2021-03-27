<template>
  <div class="mx-avatar"><b>{{ initials }}</b></div>
</template>

<script>
export default {
    name:'Avatar',
    props: {
        input: {
            type: String,
            required: true
        }
    },
    computed: {
        initials: function() {
            let splittedInput = this.input.split(' ');
            if (splittedInput.length === 1) {
                return splittedInput[0][0].toUpperCase();
            }
            return splittedInput[0][0].toUpperCase() + splittedInput[splittedInput.length - 1][0].toUpperCase();
        }
    }
};
</script>

<style>
.mx-avatar {
    display: inline-flex;    
    background: var(--color-success);
    border-radius: 50%;
    height: 32px;
    width: 32px;
    justify-content: center;
    align-items: center;
    color: var(--color-light);
    font-size: 1.1rem;
}
</style>
