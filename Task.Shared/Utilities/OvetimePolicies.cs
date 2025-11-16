namespace Task.Shared.Utilities
{
    public static class OvetimePolicies
    {
        private const decimal TaxRate = 0.09m; // 9% مالیات

        public static decimal CalculatorA(decimal basicSalary, decimal allowance)
        {
            var overTime = (basicSalary + allowance) * 0.1m; // 10% اضافه‌کار
            return basicSalary + allowance + overTime - ((basicSalary + allowance + overTime) * TaxRate);
        }

        public static decimal CalculatorB(decimal basicSalary, decimal allowance)
        {
            var overTime = (basicSalary + allowance) * 0.15m; // 15% اضافه‌کار
            return basicSalary + allowance + overTime - ((basicSalary + allowance + overTime) * TaxRate);
        }

        public static decimal CalculatorC(decimal basicSalary, decimal allowance)
        {
            var overTime = (basicSalary + allowance) * 0.2m; // 20% اضافه‌کار
            return basicSalary + allowance + overTime - ((basicSalary + allowance + overTime) * TaxRate);
        }
    }
}
