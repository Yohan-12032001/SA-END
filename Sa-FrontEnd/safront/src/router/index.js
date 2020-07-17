import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Admin from '../views/Admin.vue'
import TrocaSenha from '../views/TrocarSenha.vue'
import List from '../views/ListAgend.vue'
import Reagendamento from '../views/About.vue'


Vue.use(VueRouter)

  const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/reagend',
    name: 'reagend',
    component: Reagendamento
  },
  {
    path: '/admin',
    name: 'admin',
    component: Admin
  },
  {
    path: '/tSenha',
    name: 'TSenha',
    component: TrocaSenha
  },
  {
    path: '/list',
    name: 'List',
    component: List
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
