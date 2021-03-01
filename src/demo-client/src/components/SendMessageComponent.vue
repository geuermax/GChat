<template >
	<div class="container">
		<h3>Send message</h3>
		<div class="container">
			<select v-model="selectedChat">
				<option
					v-for="(chat, index) in chats"
					:key="index"
					:value="chat"
				>
					{{ getChatName(chat.participants) }}
				</option>
			</select>
		</div>
		<input type="text" placeholder="Message" v-model="messageText" />
		<button @click="sendMessage">Send message</button>
	</div>
</template>

<script>
import gql from "graphql-tag";
export default {
	mounted: function () {
		console.log(this.$apollo);
	},
	data: function () {
		return {
			messageText: "",
			selectedChat: null,
		};
	},
	methods: {
		sendMessage: function () {
			if (this.messageText === "" || this.selectedChat === null) {
				return;
			}
			console.log(this.selectedChat);
			this.$apollo.mutate({
				mutation: gql`
					mutation sendMessage($text: String!, $chatId: Int!) {
						sendMessage(input: { text: $text, chatId: $chatId }) {
							message {
								id
								text
							}
						}
					}
				`,
				variables: {
					chatId: this.selectedChat.id,
					text: this.messageText,
				},
				update: (store, { data }) => {
					console.log(data);
					this.$apollo.queries.chats.refetch();
				},
			});

			this.messageText = "";
			this.selectedChat = null;
		},
		getChatName: function (users) {
			let arr = users.map((i) => i.username);
			return arr.join(", ");
		},
	},
	apollo: {
		chats: {
			query: gql`
				query chats {
					chats {
						id
						participants {
							id
							username
						}
						messages {
							id
							text
						}
					}
				}
			`,
			update: (data) => {
				console.log(data);
				return data.chats;
			},
		},
	},
};
</script>

<style>
</style>
