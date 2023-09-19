
using Microsoft.AspNetCore.Http;
using MiniApp.DL.InterfaceConnect.Transaction;


namespace MiniApp.DL.Middleware;

public class DatabaseTransactionMiddleware
{
    private readonly RequestDelegate _next;

    public DatabaseTransactionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ITransactionService transactionService)
    {
        try
        {
            // Bắt đầu giao dịch
            transactionService.BeginTransaction();

            // Chuyển quyền kiểm soát đến middleware tiếp theo trong pipeline
            await _next(context);

            // Commit giao dịch nếu mọi thứ thành công
            transactionService.Commit();
        }
        catch (Exception ex)
        {
            // Rollback giao dịch nếu có lỗi
            transactionService.Rollback();
            throw ex;
        }
        finally
        {
            // Đảm bảo giải phóng tài nguyên
            transactionService.Dispose();
        }
    }
}
