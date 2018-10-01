using System.Collections.Generic;
using System.Threading.Tasks;
using PushBulletNet.PushBullet;
using PushBulletNet.PushBullet.Model;

namespace PushBulletNet
{
    public interface IPushBulletClient
    {
        /// <summary>
        /// Gets user data from PushBullet
        /// </summary>
        /// <returns></returns>
        Task<PushBulletUser> GetUserDataAsync();

        /// <summary>
        /// Gets devices registered to PushBullet
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PushBulletDevice>> GetDevicesAsync();

        /// <summary>
        /// Gets all pushes by the client on PushBullet
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PushBulletPush>> GetPushesAsync();

        /// <summary>
        /// Pushes a new request to the PushBullet service
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>

        Task PushAsync(string title, string content, string targetdeviceid);
    }

    public class PushBulletClient : IPushBulletClient
    {
        private readonly string _token;

        private readonly IPushBulletService _pushBulletService;

        public PushBulletClient(string token)
        {
            _pushBulletService = new PushBulletService();
            _token = token;
        }

        /// <inheritdoc />
        public Task<PushBulletUser> GetUserDataAsync()
        {
            return _pushBulletService.GetClientData(_token);
        }

        /// <inheritdoc />
        public Task<IEnumerable<PushBulletDevice>> GetDevicesAsync()
        {
            return _pushBulletService.GetDevices(_token);
        }

        /// <inheritdoc />
        public Task<IEnumerable<PushBulletPush>> GetPushesAsync()
        {
            return _pushBulletService.GetPushes(_token);
        }

        /// <inheritdoc />
        public Task PushAsync(string title, string content, string targetdeviceid)
        {
            return _pushBulletService.Post(_token, title, content, targetdeviceid, "pushes");
        }
    }
}