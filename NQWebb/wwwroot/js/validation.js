const requiredInputs = document.querySelectorAll("[data-val-required]");
const regexInputs = document.querySelectorAll("[data-val-regex]");
const minLengthInputs = document.querySelectorAll("[data-val-min-length]");
const confirmInputs = document.querySelectorAll("[data-val-equalto]");

function validateRequired(input) {
  if (!input.value) return input.dataset.valRequired;
}

function validateRegex(input) {
  const regex = new RegExp(input.dataset.valRegexPattern);
  if (!regex.test(input.value)) return input.dataset.valRegex;
}

function validateMinLength(input) {
  if (input.value.length < 6) return input.dataset.valMinLength;
}

function validateConfirm(input) {
  const other = document.getElementById(
    input.dataset.valEqualtoOther.substring(2)
  );
  if (input.value != other.value) return input.dataset.valEqualto;
}

function validateInputs(inputs, validationCallback) {
  for (let input of inputs) {
    input.addEventListener("input", () => {
      const span = document.querySelector(`[data-valmsg-for="${input.id}"]`);
      span.textContent = validationCallback(input);
    });
  }
}

validateInputs(requiredInputs, validateRequired);
validateInputs(regexInputs, validateRegex);
validateInputs(minLengthInputs, validateMinLength);
validateInputs(confirmInputs, validateConfirm);
