.class public Lcom/igexin/push/extension/distribution/basic/i/d/a;
.super Ljava/lang/Object;


# direct methods
.method public static a(Lcom/igexin/push/extension/distribution/basic/i/d/g;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Lcom/igexin/push/extension/distribution/basic/i/d/f;
    .locals 3

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d/f;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/d/f;-><init>()V

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/d/ac;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/b;

    invoke-direct {v2, p1, v0, p0}, Lcom/igexin/push/extension/distribution/basic/i/d/b;-><init>(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/d/f;Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    invoke-direct {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/d/ac;-><init>(Lcom/igexin/push/extension/distribution/basic/i/d/ad;)V

    invoke-virtual {v1, p1}, Lcom/igexin/push/extension/distribution/basic/i/d/ac;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    return-object v0
.end method
