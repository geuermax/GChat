<template>
	<div class="container">
		<input type="text" placeholder="Username" v-model="username" />
		<button @click="addUser">Create User</button>
	</div>
</template>

<script>
import gql from "graphql-tag";

export default {
	data: function () {
		return {
			username: "",
		};
	},
	methods: {
		addUser: function () {
			console.info("Creating user.");
			this.$apollo.mutate({
				mutation: gql`
					mutation addUser($username: String!) {
						addUser(input: { username: $username }) {
							user {
								id
								username
							}
						}
					}
				`,
				variables: {
					username: this.username,
				},
				update: ({ data }) => {
					console.log(data);
				},
			});
		},
	},
};
</script>

<style>
</style>
