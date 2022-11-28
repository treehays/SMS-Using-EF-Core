
    using SMS.interfaces;

    namespace SMS.implementation; 

    public class WalletManager : IWalletManager
    {
        private ITransactionManager _transactionManager = new TransactionManager();
        public decimal CalculateRemainingBalance()
        {
            throw new NotImplementedException();
        }
        public void CreateWallet()
        {
            throw new NotImplementedException();
        }

        public void GetTotalWalletTransaction()
        {
           
        }
    }