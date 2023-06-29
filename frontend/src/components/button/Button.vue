<template>
  <button class="button">
    <Text fontSize="var(--little-text)" color="var(--beige-color)">
      <slot></slot>
    </Text>
  </button>
</template>
    
  
<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'
  
export default defineComponent({
  name: "Button",
  components: {
    Text
  }
})
</script>
    
  
<style>
.button{
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  background-color: var(--green-color);
  border: var(--green-color);
  border-radius: 18px;
  padding: 5px 10px;
  min-width: 110px;
  font-family: var(--font-name);
}
</style>