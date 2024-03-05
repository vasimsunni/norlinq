<script setup lang="ts">
import { onMounted, ref } from 'vue'
import router from '../../router';

const noteDetails = ref('');
const errorMessage = ref('');

const baseURL = import.meta.env.VITE_API_URL + 'note';

async function addNote(){
  try {
    
    errorMessage.value = '';

    var note = {
        'details' : noteDetails.value
    }

    const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(note)
    };

    const addData = await fetch(baseURL, requestOptions);
    const response = await addData.json();

    if(response.isSuccess){
        router.push({ name: 'home' });
    }
    else{
        errorMessage = response.message;
    }
  } catch (error) {
    console.error(error);
    errorMessage = error.message;
  }
}


function cancel(){
    router.push({ name: 'home' });
}

</script>

<template>
<h2>Add new note</h2>
  <div class="item">
    <div class="details">
      <form @submit.prevent="addNote()">
        <h4>Details</h4>
        <input class="text-field" v-model="noteDetails" required />
        <div class="buttons">
            <input class="btn btn-success" type="submit" value="Add"/>
            <input class="btn btn-danger" type="button" value="Cancel" @click="cancel()"/>
        </div>
        <span class="error">{{ errorMessage }}</span>
      </form>
    </div>
  </div>
</template>

<style scoped>
.item {
  margin-top: 7px;
  display: flex;
  padding: 10px;
  border: 1px solid #ffffff;
  background:rgba(255,255,255,0.1);
  border-radius:5px;
}

.details {
  flex: 1;
}

h2 {
  font-size: 1.5rem;
  margin-bottom: 20px;
  color: var(--color-heading);
}

h4 {
  font-size: 1rem;
  margin-bottom: 10px;
  color: var(--color-heading);
}

.text-field{
    font-size: 13px;
    padding:10px;
    min-width:350px;
    display:block;
}

.buttons{
    margin-top:10px;
    text-align: right;
}

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
