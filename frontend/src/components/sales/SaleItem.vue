<template>
  <div class="sale-item">
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.purchasePrice }} ₽
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.sellingPrice }} ₽
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.wineNumber }} шт
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.date }}
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.profit }} ₽
		</Text>
  </div>
</template>
  
  
<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'
    
export default defineComponent({
  name: "SaleItem",
  components: {
    Text
  },
  props: {
    sale: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      wine: '',
      supplier: '',
    }
  },
  mounted() {
  }
})
</script>
  
  
<style scoped>
.sale-item {
  display: grid;
  grid-template-columns: 2fr 2fr 2fr 2fr 2fr;
  column-gap: 50px;
  width: 100%;
	border-top: 1px solid var(--green-color);
  padding-top: 2%;
}
</style>