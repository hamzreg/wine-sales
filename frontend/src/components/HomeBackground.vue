<template>
    <div class="bg">
      <slot></slot>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue'

  export default defineComponent({
    name: "HomeBackground"
  })
  </script>
  
  
  <style scoped>
  .bg {
    top: 0pt;
    left: 0pt;
    position: absolute;
    height: 100vh;
    width: 100vw;
    background-color: #465F5A;
    background-size: cover;
    size: cover;
  }
  </style>