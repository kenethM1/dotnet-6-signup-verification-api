public interface IPayGate
{
    PayGateResponse Pay(PayGatePaymentRequest request);
}