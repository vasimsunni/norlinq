import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import AddNoteView from '../views/note/AddView.vue'

import UpdateNoteView from '../views/note/UpdateView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/add',
      name: 'addnewnote',
      component: AddNoteView
    },
    {
      path: '/update/:noteId',
      name: 'updatenote',
      component: UpdateNoteView,
      params: true
    }
  ]
})

export default router
