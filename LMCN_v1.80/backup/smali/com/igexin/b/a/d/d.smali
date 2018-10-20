.class public abstract Lcom/igexin/b/a/d/d;
.super Lcom/igexin/b/a/d/a;


# static fields
.field protected static E:Lcom/igexin/b/a/d/e;


# instance fields
.field public A:I

.field public B:Ljava/lang/Exception;

.field public C:Ljava/lang/Object;

.field public D:Lcom/igexin/b/a/d/a/f;

.field protected final F:Ljava/util/concurrent/locks/ReentrantLock;

.field protected final G:Ljava/util/concurrent/locks/Condition;

.field H:Ljava/lang/Thread;

.field protected volatile I:Z

.field J:I

.field protected K:Lcom/igexin/b/a/d/a/c;

.field private a:B

.field protected volatile k:Z

.field protected volatile m:Z

.field protected volatile n:Z

.field protected volatile o:Z

.field protected volatile p:Z

.field protected volatile q:Z

.field protected volatile r:Z

.field protected volatile s:Z

.field protected volatile t:Z

.field protected volatile u:J

.field volatile v:I

.field public w:J

.field public x:I

.field public y:I

.field public z:I


# direct methods
.method public constructor <init>(I)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, p1, v0}, Lcom/igexin/b/a/d/d;-><init>(ILcom/igexin/b/a/d/a/c;)V

    return-void
.end method

.method public constructor <init>(ILcom/igexin/b/a/d/a/c;)V
    .locals 1

    invoke-direct {p0}, Lcom/igexin/b/a/d/a;-><init>()V

    iput p1, p0, Lcom/igexin/b/a/d/d;->z:I

    iput-object p2, p0, Lcom/igexin/b/a/d/d;->K:Lcom/igexin/b/a/d/a/c;

    new-instance v0, Ljava/util/concurrent/locks/ReentrantLock;

    invoke-direct {v0}, Ljava/util/concurrent/locks/ReentrantLock;-><init>()V

    iput-object v0, p0, Lcom/igexin/b/a/d/d;->F:Ljava/util/concurrent/locks/ReentrantLock;

    iget-object v0, p0, Lcom/igexin/b/a/d/d;->F:Ljava/util/concurrent/locks/ReentrantLock;

    invoke-virtual {v0}, Ljava/util/concurrent/locks/ReentrantLock;->newCondition()Ljava/util/concurrent/locks/Condition;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/b/a/d/d;->G:Ljava/util/concurrent/locks/Condition;

    return-void
.end method


# virtual methods
.method public final a(JLjava/util/concurrent/TimeUnit;)I
    .locals 5

    const/4 v0, 0x0

    const-wide/16 v2, 0x0

    cmp-long v1, p1, v2

    if-lez v1, :cond_0

    sget-object v1, Lcom/igexin/b/a/d/d;->E:Lcom/igexin/b/a/d/e;

    iget-object v1, v1, Lcom/igexin/b/a/d/e;->k:Lcom/igexin/b/a/d/c;

    invoke-virtual {v1, p0, p1, p2, p3}, Lcom/igexin/b/a/d/c;->a(Lcom/igexin/b/a/d/d;JLjava/util/concurrent/TimeUnit;)I

    move-result v1

    packed-switch v1, :pswitch_data_0

    :cond_0
    :goto_0
    :pswitch_0
    return v0

    :pswitch_1
    const/4 v0, -0x2

    goto :goto_0

    :pswitch_2
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    sget-object v2, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {v2, p1, p2, p3}, Ljava/util/concurrent/TimeUnit;->convert(JLjava/util/concurrent/TimeUnit;)J

    move-result-wide v2

    add-long/2addr v0, v2

    iput-wide v0, p0, Lcom/igexin/b/a/d/d;->u:J

    const/4 v0, -0x1

    goto :goto_0

    :pswitch_3
    const/4 v0, 0x1

    goto :goto_0

    :pswitch_data_0
    .packed-switch -0x2
        :pswitch_1
        :pswitch_2
        :pswitch_0
        :pswitch_3
    .end packed-switch
.end method

.method public a(Ljava/util/concurrent/TimeUnit;)J
    .locals 3

    invoke-virtual {p0}, Lcom/igexin/b/a/d/d;->o()J

    move-result-wide v0

    sget-object v2, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {p1, v0, v1, v2}, Ljava/util/concurrent/TimeUnit;->convert(JLjava/util/concurrent/TimeUnit;)J

    move-result-wide v0

    return-wide v0
.end method

.method public final a(I)V
    .locals 2

    iget-byte v0, p0, Lcom/igexin/b/a/d/d;->a:B

    and-int/lit8 v0, v0, 0xf

    int-to-byte v0, v0

    iput-byte v0, p0, Lcom/igexin/b/a/d/d;->a:B

    iget-byte v0, p0, Lcom/igexin/b/a/d/d;->a:B

    and-int/lit8 v1, p1, 0xf

    shl-int/lit8 v1, v1, 0x4

    or-int/2addr v0, v1

    int-to-byte v0, v0

    iput-byte v0, p0, Lcom/igexin/b/a/d/d;->a:B

    return-void
.end method

.method public final a(ILcom/igexin/b/a/d/a/f;)V
    .locals 2

    if-gez p1, :cond_0

    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "second must > 0"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_0
    iput p1, p0, Lcom/igexin/b/a/d/d;->y:I

    iput-object p2, p0, Lcom/igexin/b/a/d/d;->D:Lcom/igexin/b/a/d/a/f;

    return-void
.end method

.method public final a(Lcom/igexin/b/a/d/a/c;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/b/a/d/d;->K:Lcom/igexin/b/a/d/a/c;

    return-void
.end method

.method public a_()V
    .locals 1

    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/b/a/d/d;->H:Ljava/lang/Thread;

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/b/a/d/d;->p:Z

    return-void
.end method

.method public final b(J)V
    .locals 1

    iput-wide p1, p0, Lcom/igexin/b/a/d/d;->w:J

    return-void
.end method

.method public c()V
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->k:Z

    if-nez v0, :cond_0

    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->m:Z

    if-eqz v0, :cond_1

    :cond_0
    invoke-virtual {p0}, Lcom/igexin/b/a/d/d;->f()V

    :cond_1
    return-void
.end method

.method public d()V
    .locals 1

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/b/a/d/d;->s:Z

    return-void
.end method

.method protected abstract e()V
.end method

.method public f()V
    .locals 1

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/igexin/b/a/d/d;->C:Ljava/lang/Object;

    iput-object v0, p0, Lcom/igexin/b/a/d/d;->B:Ljava/lang/Exception;

    iput-object v0, p0, Lcom/igexin/b/a/d/d;->H:Ljava/lang/Thread;

    return-void
.end method

.method final n()V
    .locals 2

    iget v0, p0, Lcom/igexin/b/a/d/d;->J:I

    add-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/igexin/b/a/d/d;->J:I

    iget v0, p0, Lcom/igexin/b/a/d/d;->J:I

    const v1, 0x40fffffe    # 7.999999f

    and-int/2addr v0, v1

    iput v0, p0, Lcom/igexin/b/a/d/d;->J:I

    return-void
.end method

.method o()J
    .locals 4

    iget-wide v0, p0, Lcom/igexin/b/a/d/d;->u:J

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    sub-long/2addr v0, v2

    return-wide v0
.end method

.method public final p()V
    .locals 1

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/b/a/d/d;->k:Z

    return-void
.end method

.method public final q()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->n:Z

    return v0
.end method

.method public final r()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->m:Z

    return v0
.end method

.method public final s()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->k:Z

    return v0
.end method

.method protected t()V
    .locals 0

    return-void
.end method

.method public final u()V
    .locals 1

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/b/a/d/d;->m:Z

    return-void
.end method

.method protected v()V
    .locals 2

    const/4 v1, 0x0

    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->o:Z

    if-nez v0, :cond_1

    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->q:Z

    if-nez v0, :cond_1

    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->r:Z

    if-nez v0, :cond_1

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/b/a/d/d;->k:Z

    iput-boolean v1, p0, Lcom/igexin/b/a/d/d;->p:Z

    :cond_0
    :goto_0
    return-void

    :cond_1
    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->q:Z

    if-eqz v0, :cond_2

    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->k:Z

    if-nez v0, :cond_2

    iput-boolean v1, p0, Lcom/igexin/b/a/d/d;->p:Z

    goto :goto_0

    :cond_2
    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->o:Z

    if-eqz v0, :cond_0

    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->n:Z

    if-nez v0, :cond_0

    iget-boolean v0, p0, Lcom/igexin/b/a/d/d;->k:Z

    if-nez v0, :cond_0

    iput-boolean v1, p0, Lcom/igexin/b/a/d/d;->p:Z

    goto :goto_0
.end method

.method protected w()V
    .locals 2

    iget-object v0, p0, Lcom/igexin/b/a/d/d;->K:Lcom/igexin/b/a/d/a/c;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/d/d;->K:Lcom/igexin/b/a/d/a/c;

    sget-object v1, Lcom/igexin/b/a/d/a/d;->a:Lcom/igexin/b/a/d/a/d;

    invoke-interface {v0, v1}, Lcom/igexin/b/a/d/a/c;->a(Lcom/igexin/b/a/d/a/d;)V

    :cond_0
    return-void
.end method
