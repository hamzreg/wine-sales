<template>
  <button class="form-button">
    <Text fontSize="var(--little-text)" color="var(--emerald-color)">
      <slot></slot>
    </Text>
  </button>
</template>
    

<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'
  
export default defineComponent({
  name: "FormButton",
  components: {
    Text
  }
})
</script>
    
  
<style>
.form-button{
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  background-color: var(--beige-color);
  border: 1px solid var(--emerald-color);
  border-radius: 18px;
  padding: 5px 10px;
  font-family: var(--font-name);
}
</style>