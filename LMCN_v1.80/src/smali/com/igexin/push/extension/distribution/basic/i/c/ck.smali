.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/ck;
.super Lcom/igexin/push/extension/distribution/basic/i/c/ar;


# direct methods
.method constructor <init>(Ljava/lang/String;I)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, p1, p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ar;-><init>(Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/i/c/as;)V

    return-void
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/i/c/aq;Lcom/igexin/push/extension/distribution/basic/i/c/a;)V
    .locals 1

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->c()C

    move-result v0

    sparse-switch v0, :sswitch_data_0

    const/4 v0, 0x2

    new-array v0, v0, [C

    fill-array-data v0, :array_0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->a([C)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Ljava/lang/String;)V

    :goto_0
    return-void

    :sswitch_0
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ck;->n:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :sswitch_1
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->f()V

    const v0, 0xfffd

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(C)V

    goto :goto_0

    :sswitch_2
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/ak;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ak;-><init>()V

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)V

    goto :goto_0

    nop

    :sswitch_data_0
    .sparse-switch
        0x0 -> :sswitch_1
        0x3c -> :sswitch_0
        0xffff -> :sswitch_2
    .end sparse-switch

    :array_0
    .array-data 2
        0x3cs
        0x0s
    .end array-data
.end method
