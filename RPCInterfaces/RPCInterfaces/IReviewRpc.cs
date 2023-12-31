﻿using RPCInterface.RPCImplementations;

namespace RPCInterface.RPCInterfaces;

public interface IReviewRpc : IRpcBase<Review>
{
    Task<ICollection<Review>> GetAllReviewsByItemIdAsync(int itemId);
}