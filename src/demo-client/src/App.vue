<template>
	<div id="app">
		<h2>Logged in as {{ login }}</h2>
		<div class="conatiner">
			<img alt="Vue logo" src="./assets/logo.png" />
		</div>
		<!-- <HelloWorld msg="Welcome to Your Vue.js App"/> -->
		<create-user-component />
		<create-chat-component />
	</div>
</template>

<script>
// import HelloWorld from './components/HelloWorld.vue'
import CreateUserComponent from "@/components/CreateUserComponent.vue";
import CreateChatComponent from "./components/CreateChatComponent.vue";

export default {
	name: "App",
	components: {
		// HelloWorld,
		CreateUserComponent,
		CreateChatComponent,
	},
	computed: {
		login: () => {
			return window.keycloak.tokenParsed.preferred_username;
		},
	},
};
</script>

<style>
#app {
	font-family: Avenir, Helvetica, Arial, sans-serif;
	-webkit-font-smoothing: antialiased;
	-moz-osx-font-smoothing: grayscale;
	text-align: center;
	color: #2c3e50;
	margin-top: 60px;
}

.container {
	display: block;
	margin: 15px;
	width: 300px;
	margin-left: auto;
	margin-right: auto;
}
</style>
