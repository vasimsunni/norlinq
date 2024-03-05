<script setup lang="ts">
import NoteItem from './NoteItem.vue'
import { onMounted, ref } from 'vue'
import router from '../../router';

let id = 0
const errorMessage = ref('')
const notes = ref([])

const baseURL = 'https://localhost:44366/api/note' 

fetchNotes();

async function fetchNotes() {
  try {
    
    errorMessage.value = '';

    const fetchData = await fetch(baseURL);
    const response = await fetchData.json();;
    console.log(response);
    if(response.isSuccess){
        notes.value = response.data;
    }
    else{
        errorMessage = response.message;
    }
  } catch (error) {
    console.error(error);
  }
}

function addNewNote(){
    router.push({ name: 'addnewnote' });
}

function editNote(id){
    console.log('edit note: '+id);
}

function deleteNote(id){
    console.log('delete note: '+id);
}

</script>



<template>
    <h1>Note App</h1>
    <span class="error">{{ errorMessage }}</span>
    <button class="btn btn-success" @click="addNewNote()">Add New Note</button>
    <NoteItem v-for="item in notes" :key="item.id">
        <template #title>{{ item.details }}</template>
        <template #edit>
            <button class="btn btn-info" @click="editNote(item.id)">Edit</button>
        </template>
        <template #delete>
            <button class="btn btn-danger" @click="deleteNote(item.id)">Delete</button>
        </template>
    </NoteItem>
</template>

<style scoped>
.btn {
  margin: 0px 5px 5px 0px;
  padding: 5px;
  border: 1px solid #ffffff;
  background:rgba(255,255,255,0.1);
  border-radius:5px;
}

.btn-success{
    background-color:#169318;
    color:white;
}
.btn-info{
    background-color:#296CE1;
    color:white;
}

.btn-danger{
    background-color:#E14A29;
    color:white;
}

.error{
    color:#E14A29;
    display:block;
    margin-top:10px;
}
</style>
