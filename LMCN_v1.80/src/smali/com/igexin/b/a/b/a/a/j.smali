.class public final Lcom/igexin/b/a/b/a/a/j;
.super Lcom/igexin/b/a/b/a/a/a;


# static fields
.field private static final L:Ljava/lang/String;


# instance fields
.field private M:Lcom/igexin/b/a/b/a/a/a/b;

.field private N:[B

.field private O:Lcom/igexin/b/a/b/d;

.field i:Lcom/igexin/b/a/b/a/a/m;

.field j:Lcom/igexin/b/a/b/b;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const-class v0, Lcom/igexin/b/a/b/a/a/j;

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/igexin/b/a/b/a/a/j;->L:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>(Lcom/igexin/b/a/b/a/a/m;Lcom/igexin/b/a/b/b;Lcom/igexin/b/a/b/d;)V
    .locals 2

    const/16 v0, -0x7f3

    const/4 v1, 0x0

    invoke-direct {p0, v0, v1, p2}, Lcom/igexin/b/a/b/a/a/a;-><init>(ILjava/lang/String;Lcom/igexin/b/a/b/b;)V

    iput-object p2, p0, Lcom/igexin/b/a/b/a/a/j;->j:Lcom/igexin/b/a/b/b;

    iput-object p1, p0, Lcom/igexin/b/a/b/a/a/j;->i:Lcom/igexin/b/a/b/a/a/m;

    iput-object p3, p0, Lcom/igexin/b/a/b/a/a/j;->O:Lcom/igexin/b/a/b/d;

    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/b/a/b/a/a/a/b;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/b/a/b/a/a/j;->M:Lcom/igexin/b/a/b/a/a/a/b;

    return-void
.end method

.method public a_()V
    .locals 5

    invoke-super {p0}, Lcom/igexin/b/a/b/a/a/a;->a_()V

    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v2, Lcom/igexin/b/a/b/a/a/j;->L:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "|"

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, " running"

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    :cond_0
    :goto_0
    iget-boolean v0, p0, Lcom/igexin/b/a/b/a/a/j;->h:Z

    if-eqz v0, :cond_2

    invoke-virtual {v1}, Ljava/lang/Thread;->isInterrupted()Z

    move-result v0

    if-nez v0, :cond_2

    iget-boolean v0, p0, Lcom/igexin/b/a/b/a/a/j;->e:Z

    if-nez v0, :cond_2

    :try_start_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->j:Lcom/igexin/b/a/b/b;

    const/4 v2, 0x0

    iget-object v3, p0, Lcom/igexin/b/a/b/a/a/j;->O:Lcom/igexin/b/a/b/d;

    iget-object v4, p0, Lcom/igexin/b/a/b/a/a/j;->i:Lcom/igexin/b/a/b/a/a/m;

    invoke-virtual {v0, v2, v3, v4}, Lcom/igexin/b/a/b/b;->c(Lcom/igexin/b/a/b/e;Lcom/igexin/b/a/b/d;Ljava/lang/Object;)Ljava/lang/Object;

    sget-object v0, Lcom/igexin/b/a/b/a/a/b;->a:Lcom/igexin/b/a/b/a/a/b;

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->f:Lcom/igexin/b/a/b/a/a/b;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    move-exception v0

    const/4 v2, 0x0

    iput-boolean v2, p0, Lcom/igexin/b/a/b/a/a/j;->h:Z

    iget-object v2, p0, Lcom/igexin/b/a/b/a/a/j;->f:Lcom/igexin/b/a/b/a/a/b;

    sget-object v3, Lcom/igexin/b/a/b/a/a/b;->c:Lcom/igexin/b/a/b/a/a/b;

    if-eq v2, v3, :cond_0

    sget-object v2, Lcom/igexin/b/a/b/a/a/b;->b:Lcom/igexin/b/a/b/a/a/b;

    iput-object v2, p0, Lcom/igexin/b/a/b/a/a/j;->f:Lcom/igexin/b/a/b/a/a/b;

    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    if-eqz v2, :cond_1

    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    const-string v3, "read = -1, end of stream !"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_1

    const-string v0, "end of stream"

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->g:Ljava/lang/String;

    goto :goto_0

    :cond_1
    invoke-virtual {v0}, Ljava/lang/Throwable;->toString()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->g:Ljava/lang/String;

    goto :goto_0

    :cond_2
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/b/a/b/a/a/j;->e:Z

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igexin/b/a/b/a/a/j;->L:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "|finish ~~~~~~"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    return-void
.end method

.method public final b()I
    .locals 1

    const/16 v0, -0x7f3

    return v0
.end method

.method public f()V
    .locals 4

    const/4 v3, 0x0

    invoke-super {p0}, Lcom/igexin/b/a/b/a/a/a;->f()V

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igexin/b/a/b/a/a/j;->L:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "|dispose"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->M:Lcom/igexin/b/a/b/a/a/a/b;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->f:Lcom/igexin/b/a/b/a/a/b;

    sget-object v1, Lcom/igexin/b/a/b/a/a/b;->b:Lcom/igexin/b/a/b/a/a/b;

    if-ne v0, v1, :cond_2

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->g:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->M:Lcom/igexin/b/a/b/a/a/a/b;

    new-instance v1, Ljava/lang/Exception;

    iget-object v2, p0, Lcom/igexin/b/a/b/a/a/j;->g:Ljava/lang/String;

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-interface {v0, v1}, Lcom/igexin/b/a/b/a/a/a/b;->a(Ljava/lang/Exception;)V

    :cond_0
    :goto_0
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->N:[B

    if-eqz v0, :cond_1

    iput-object v3, p0, Lcom/igexin/b/a/b/a/a/j;->N:[B

    :cond_1
    iput-object v3, p0, Lcom/igexin/b/a/b/a/a/j;->M:Lcom/igexin/b/a/b/a/a/a/b;

    return-void

    :cond_2
    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->M:Lcom/igexin/b/a/b/a/a/a/b;

    invoke-interface {v0, p0}, Lcom/igexin/b/a/b/a/a/a/b;->a(Lcom/igexin/b/a/b/e;)V

    goto :goto_0
.end method

.method public h()V
    .locals 1

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/b/a/b/a/a/j;->h:Z

    sget-object v0, Lcom/igexin/b/a/b/a/a/b;->c:Lcom/igexin/b/a/b/a/a/b;

    iput-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->f:Lcom/igexin/b/a/b/a/a/b;

    :try_start_0
    iget-boolean v0, p0, Lcom/igexin/b/a/b/a/a/j;->e:Z

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->i:Lcom/igexin/b/a/b/a/a/m;

    iget-object v0, v0, Lcom/igexin/b/a/b/a/a/m;->a:Ljava/io/BufferedInputStream;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/b/a/a/j;->i:Lcom/igexin/b/a/b/a/a/m;

    iget-object v0, v0, Lcom/igexin/b/a/b/a/a/m;->a:Ljava/io/BufferedInputStream;

    invoke-virtual {v0}, Ljava/lang/Object;->notifyAll()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :cond_0
    :goto_0
    return-void

    :catch_0
    move-exception v0

    goto :goto_0
.end method
