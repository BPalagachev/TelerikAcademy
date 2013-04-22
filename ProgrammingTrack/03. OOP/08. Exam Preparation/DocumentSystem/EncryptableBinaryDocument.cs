using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class EncryptableBinaryDocument : BinaryDocument, IEncryptable
{
    protected bool isEncrypted = false;

    public virtual bool IsEncrypted
    {
        get
        {
            return this.isEncrypted;
        }
    }

    public virtual void Encrypt()
    {
        this.isEncrypted = true;
    }

    public virtual void Decrypt()
    {
        this.isEncrypted = false;
    }

    public override string ToString()
    {
        if (this.IsEncrypted == true)
        {
            return this.GetType().Name + "[encrypted]";
        }
        else
        {
            return base.ToString();
        }
    }
}
