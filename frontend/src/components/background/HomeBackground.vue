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
  position: absolute;
  top: 0%;
  left: 0%;
  height: 100vh;
  width: 100vw;
  background-color: var(--green-color);
  size: cover;
}
</style>