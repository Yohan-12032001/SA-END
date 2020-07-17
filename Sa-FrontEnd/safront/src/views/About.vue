<template>
  <div class="about">
    <img alt="Vue logo" src="../assets/logo2.jpg" width="150px">
    <reagendamento/>
  </div>
</template>

<script>
import Reagendamento from '../components/Reagendamento.vue'

export default {
  components: {
        Reagendamento
    }
  
}
</script>

<style>
  img{
    margin-right: 40px ;
  }
</style>
