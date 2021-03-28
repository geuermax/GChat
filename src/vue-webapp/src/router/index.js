import Vue from 'vue';
import VueRouter from 'vue-router';
import Index from '../views/Index.vue';
import Home from '../views/Home.vue';
import Chat from '@/components/Chat.vue';


Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    children: [
      {
        path: '/',
        name: 'Index',
        component: Index
      },
      {
        path: 'chat',
        name: 'Chat',
        component: Chat
      }
    ]
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: function () {
      return import(/* webpackChunkName: "about" */ '../views/About.vue');
    }
  }
];

const router = new VueRouter({
  routes
});

export default router;
