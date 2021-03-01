<template>
	<div class="container">
		<h3>Create chat</h3>
		<select v-model="selectedUser">
			<option v-for="user in users" :key="user.id" :value="user">
				{{ user.username }}
			</option>
		</select>
		<ul>
			<li v-for="(user, index) in selectedUsers" :key="index">
				{{ user.username }}
			</li>
		</ul>
		<button @click="addUser">Add User</button>
		<button @click="addChat">Create Chat</button>
	</div>
</template>

<script>
import gql from "graphql-tag";
export default {
	data: function () {
		return {
			selectedUser: null,
			selectedUsers: [],
		};
	},
	methods: {
		addUser: function () {
			if (this.selectedUser != null) {
				console.log(this.selectedUsers);
				this.selectedUsers.push(this.selectedUser);
				this.selectedUser = null;
			}
		},
		addChat: function () {
			if (this.selectedUsers.length > 0) {
				let users = [...new Set(this.selectedUsers)];
				let userIds = users.map((m) => m.id);
				console.log(userIds);
				this.selectedUsers = [];
				this.$apollo.mutate({
					mutation: gql`
						mutation addChat($userIds: [String!]!) {
							addChat(input: { userIds: $userIds }) {
								chat {
									id
									participants {
										username
									}
								}
							}
						}
					`,
					variables: {
						userIds: userIds,
					},
					update: function ({ data }) {
						console.log(data);
					},
				});
			}
		},
	},
	apollo: {
		users: {
			query: gql`
				query users {
					users {
						id
						username
					}
				}
			`,
			update: (data) => {
				console.log(data.users);
				return data.users;
			},
		},
	},
};
</script>

<style>
</style>
