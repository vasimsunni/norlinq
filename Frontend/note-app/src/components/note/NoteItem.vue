<template>
  <div class="item">
    <div class="details">
      <h4>
        <slot name="title"></slot>
      </h4>
      <slot name="edit"></slot>
      <slot name="delete"></slot>
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

h4 {
  font-size: 1.2rem;
  margin-bottom: 0.4rem;
  color: var(--color-heading);
}

</style>
