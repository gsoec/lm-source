.class public Lcom/igexin/push/d/h;
.super Lcom/igexin/b/a/d/b;


# direct methods
.method public constructor <init>()V
    .locals 1

    invoke-direct {p0}, Lcom/igexin/b/a/d/b;-><init>()V

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/d/h;->a:Z

    return-void
.end method


# virtual methods
.method public a()V
    .locals 0

    invoke-super {p0}, Lcom/igexin/b/a/d/b;->a()V

    return-void
.end method

.method public a(Lcom/igexin/b/a/d/d;)V
    .locals 1

    sget-boolean v0, Lcom/igexin/push/core/g;->l:Z

    if-eqz v0, :cond_0

    invoke-static {}, Lcom/igexin/push/f/b/c;->g()Lcom/igexin/push/f/b/c;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/f/b/c;->i()V

    :cond_0
    invoke-virtual {p0}, Lcom/igexin/push/d/h;->a()V

    return-void
.end method
