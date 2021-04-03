export default {
    state: {
        chats: []
    },
    mutations: {
        setChats: (state, chats) => {
            state.chats = chats;
        }
    },
    getters: {
        getChatById: (state) => (chatId) => {
            let result = state.chats.find(i => i.id === chatId);
            return result.length > 0 ? result[0] : null;
        }
    }
};
