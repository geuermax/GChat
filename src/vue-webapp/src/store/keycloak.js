export default {
    state: {
        keycloak: null
    },
    mutations: {
        setKeycloak: (state, keycloak) => {
            state.keycloak = keycloak;
        }
    },
    getters: {
        getUsername: (state) => {
            if (state.keycloak == null) {
                throw new Error('No keycloak instace saved.');
            }
            return state.keycloak.tokenParsed.preferred_username;
        },
        getToken: (state) => {
            if (state.keycloak == null) {
                throw new Error('No keycloak instace saved.');
            }
            return state.keycloak.token;
        },
        getSubject: (state) => { // subject
            if (state.keycloak == null) {
                throw new Error('No keycloak instace saved.');
            }
            return state.keycloak.tokenParsed.sub;
        },
        getClaims: (state) => (claimId) => {
            if (state.keycloak == null) {
                throw new Error('No keycloak instace saved.');
            }
            return state.keycloak.tokenParsed[claimId];
        }
    }
};
